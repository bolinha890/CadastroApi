function createPessoa(){
    const primeiroNome= document.getElementById("firstName").value;
    const segundonome= document.getElementById("middleName").value;
    const ultimoNome= document.getElementById("lastname").value;
    const cpf= document.getElementById("cpf").value;


    const data={
        primeiroNome:primeiroNome,
        nomeMeio : segundonome,
        Ultimonome : ultimoNome,
        cpf : cpf
    
    }
    fetch('https://localhost:7195/api/Pessoa/Create', {
    method: 'POST',
    headers: {
        'content-type': 'application/json'
    },
    body: JSON.stringify(data)
}).then(response =>{
    if (!response.ok){
        alert ("Erro ao criar pessoa");
    }
    alert ("pessoa criada com sucesso!"),
    window.location.href = '../index.html';
})
}