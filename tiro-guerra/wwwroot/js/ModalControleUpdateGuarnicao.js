var atiradores = [];
var sentinelas = [];
var atiradoresLista = [];
var lista_nova=[];
var id_dia;


//modal
//exibe o modal na tela
function showModal(idModal)
{
    id_dia = idModal;   
    var element = document.getElementById("modal");
    element.classList.add("show-modal");
}

//esconde o modal
function disposeModal()
{
    var element = document.getElementById("modal");
    element.classList.remove("show-modal");
}

//deleta um sentinela da lista de sentinelas
function deleteItem(atirador)
{
    let listaAtiradores = document.querySelector('.myList');
    listaAtiradores.innerHTML ="";

    var buscar_por;
    var indice_remover;
    
    

    atiradores.forEach(function (item, indice, array)
     {
         if(item != atirador)
         {
            listaAtiradores.innerHTML +=`
            <div class="linha-lista">
                <div class="list-space">
                    <li class='item-lista' id='`+item+`'> `+item+`</li>
                </div>
        
                <div class="list-space">
                    <span  class='span-item-lista' onClick="deleteItem('`+item+`')"> X </span>
                </div> 
            </div>`
        }
     });

     buscar_por = atirador;
     indice_remover = atiradores.indexOf(buscar_por); 

     while(indice_remover>=0)
     {
         atiradores.splice(indice_remover,1);
         atiradoresLista.splice(indice_remover,1);

         indice_remover = atiradores.indexOf(buscar_por);

     }

     //console.log('Quantidade de atiradores '+atiradores.length);

}

//adiciona 1 sentinela a lista de sentinelas
document.querySelector('input[value=Adicionar]').addEventListener('click',() =>
{
   
    var select = document.getElementById('sentinela');
    var value = select.options[select.selectedIndex].text;
    var valueId = select.options[select.selectedIndex].value;

    if(atiradores.length < 6)
    {
        let atiradorEstaNaLista = false;
        atiradores.forEach(function (item, indice)
        {
            if(value == item)
            {
                atiradorEstaNaLista = true;
            }
        });

        if(atiradorEstaNaLista == false)
        {
            atiradores.push(value);
    
            atiradoresLista.push({
                id:valueId,
                nome: value,
                funcao: 'Sentinela'
            });
    
            let listaAtiradores = document.querySelector('.myList');
            listaAtiradores.innerHTML += `
            <div class="linha-lista">
                <div class="list-space">
                    <li class='item-lista' id='`+value+`'> `+value+`</li>
                </div>
    
                <div class="list-space">
                    <span  class='span-item-lista' onClick="deleteItem('`+value+`')"> X </span>
                </div> 
            </div>`
        }
   
    }

    select = "";
    value="";
    
});


//limpa a lista com os nomes de sentinelas
document.querySelector('input[value=Limpar]').addEventListener('click',() =>
{
    atiradores = [];
    sentinelas = [];
    atiradoresLista = [];

    let listaAtiradores = document.querySelector('.myList');
    listaAtiradores.innerHTML = ""

});

//Recebe as informações dos sentinelas e dos outros membros da guarda
document.querySelector('input[class=save]').addEventListener('click',() =>
{
    //Leitura dos valores descritos no select
    var select = document.getElementById('fiscal');
    var FiscalId = select.options[select.selectedIndex].value;
    var fiscalName = select.options[select.selectedIndex].text;

    var select = document.getElementById('comandante');
    var ComandanteId = select.options[select.selectedIndex].value;
    var ComandanteName = select.options[select.selectedIndex].text;

    var select = document.getElementById('cabo');
    var CaboID = select.options[select.selectedIndex].value;
    var CaboName = select.options[select.selectedIndex].text;

    //console.log(atiradoresLista);
    //atualiza o valor do dia para bater com o indice 0 do array
    var index = id_dia -1;

    //leitura dos valores do id, nome e id da guarnição do fiscal que sera alterado
    let linhaFiscaisSemanaId = document.querySelectorAll('#linha-fiscal td .idFiscal');
    let linhaFiscaisSemanaNome = document.querySelectorAll('#linha-fiscal td .nomeFiscal');
    let linhaFiscaisSemanaIdguarnicao = document.querySelectorAll('#linha-fiscal td .idGuarnicao');

    //leitura dos valores do id, nome e id da guarnição do comandante que sera alterado
    let linhaComandantesSemanaId = document.querySelectorAll('#linha-comandante td .idComandante');
    let linhaComandantesSemanaNome = document.querySelectorAll('#linha-comandante td .nome');
    let linhaComandantesSemanaIdGuarda = document.querySelectorAll('#linha-comandante td .idGuarda');

    //leitura dos valores do id, nome e id da guarnição do cabo que sera alterado
    let linhaCabosSemanaId = document.querySelectorAll('#linha-cabo td .IdCabos');
    let linhaCabosSemanaNome = document.querySelectorAll('#linha-cabo td .nome');
    let linhaCabosSemanaIdGuarda = document.querySelectorAll('#linha-cabo td .idGuarda');

    //remove o campo nome e id do atirador que sera alterado
    linhaFiscaisSemanaId[index].remove();
    linhaFiscaisSemanaNome[index].remove();

    //Adiciona o novo item após o id da guarda
    linhaFiscaisSemanaIdguarnicao[index].insertAdjacentHTML("afterend",`
            <input class="idFiscal" name="idfiscal" type="hidden" value="`+FiscalId+`">
            <label class="nomeFiscal" name="nomeFiscal">`+fiscalName+`</label>
    `);

    linhaComandantesSemanaId[index].remove();
    linhaComandantesSemanaNome[index].remove();
    
    linhaComandantesSemanaIdGuarda[index].insertAdjacentHTML("afterend",`
    <input class="idComandante" name="idAtirador" type="hidden" value="`+ComandanteId+`">
    <label class="nome" name="nome">`+ComandanteName+`</label>
    `);
    
    linhaCabosSemanaId[index].remove();
    linhaCabosSemanaNome[index].remove();

    linhaCabosSemanaIdGuarda[index].insertAdjacentHTML("afterend",`
    <input class="IdCabos" name="idAtirador" type="hidden" value="`+CaboID+`">
    <label class="nome" name="nome">`+CaboName+`</label>`);

    let classe;
    var contador = 1;

    let linhaSentinelaSemanaId;
    let linhaSentinelaSemanaNome;
    let linhaSentinelaSemanaIdGuarda;

    //percorre a lista de sentinelas para atualizar a tela
    atiradoresLista.forEach(function (item, indice, array)
     {

        //Recupera a linha que sera alterada
        classe ='#linha-sentinela0'+contador+' td';
        contador+=1;

        //recebe os valores atuais
        linhaSentinelaSemanaId = document.querySelectorAll(classe+" .idAtirador");
        linhaSentinelaSemanaNome = document.querySelectorAll(classe+" .nome");
        linhaSentinelaSemanaIdGuarda = document.querySelectorAll(classe+" .idGuarda");

        //remove os valores de nome e id
        linhaSentinelaSemanaId[index].remove();
        linhaSentinelaSemanaNome[index].remove();

        //insere ao final os novos valores de nome e Id
        linhaSentinelaSemanaIdGuarda[index].insertAdjacentHTML("afterend",
        `<input class="idAtirador" name="idAtirador" type="hidden" value="`+item.id+`">
        <label class="nome" name="nome">`+item.nome+`</label>`);
    });

    //Limpa a lista do modal
    let listaAtiradores = document.querySelector('.myList');
    listaAtiradores.innerHTML = ""

     atiradores = [];
     sentinelas = [];
     atiradoresLista = [];
     id_dia = "";
     contador =1;

     disposeModal();

});
