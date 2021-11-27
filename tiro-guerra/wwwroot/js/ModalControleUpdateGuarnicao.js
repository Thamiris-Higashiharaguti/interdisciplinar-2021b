var atiradores = [];
var sentinelas = [];
var atiradoresLista = [];
var lista_nova=[];
var id_dia;


//modal

function showModal(idModal)
{
    id_dia = idModal;   
    var element = document.getElementById("modal");
    element.classList.add("show-modal");
}

function disposeModal()
{
    var element = document.getElementById("modal");
    element.classList.remove("show-modal");
}


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

     console.log('Quantidade de atiradores '+atiradores.length);

}

//adiciona 1 sentinela a lista
document.querySelector('input[value=Adicionar]').addEventListener('click',() =>
{
   
    var select = document.getElementById('sentinela');
    var value = select.options[select.selectedIndex].text;
    var valueId = select.options[select.selectedIndex].value;

    if(atiradores.length < 6)
    {

        atiradores.push(value)
    
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
        
         
       //  <li id="Amaro">Teste  <span onclick="deleteItem('Amaro')">X</span> </li>  

       /*
          <div class="list-space">
                                        <li class="item-lista" id="Teste">Teste   </li>
                                    </div>
                                    <div class="list-space">
                                         <span class="span-item-lista" onclick="deleteItem('Teste')">X</span> 
                                    </div> 
       */
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

    

    var select = document.getElementById('fiscal');
    var FiscalId = select.options[select.selectedIndex].value;
    var fiscalName = select.options[select.selectedIndex].text;

    var select = document.getElementById('comandante');
    var ComandanteId = select.options[select.selectedIndex].value;
    var ComandanteName = select.options[select.selectedIndex].text;

    var select = document.getElementById('cabo');
    var CaboID = select.options[select.selectedIndex].value;
    var CaboName = select.options[select.selectedIndex].text;

    console.log(atiradoresLista);
      
    var index = id_dia -1;

    let linhaFiscaisSemanaId = document.querySelectorAll('#linha-fiscal td .idFiscal');
    let linhaFiscaisSemanaNome = document.querySelectorAll('#linha-fiscal td .nome');
    let linhaFiscaisSemanaIdguarnicao = document.querySelectorAll('#linha-fiscal td .idGuarnicao');


    let linhaComandantesSemanaId = document.querySelectorAll('#linha-comandante td .idComandante');
    let linhaComandantesSemanaNome = document.querySelectorAll('#linha-comandante td .nome');
    let linhaComandantesSemanaIdGuarda = document.querySelectorAll('#linha-comandante td .idGuarda');


    let linhaCabosSemanaId = document.querySelectorAll('#linha-cabo td .IdCabos');
    let linhaCabosSemanaNome = document.querySelectorAll('#linha-cabo td .nome');
    let linhaCabosSemanaIdGuarda = document.querySelectorAll('#linha-cabo td .idGuarda');

    linhaFiscaisSemanaId[index].remove();
    linhaFiscaisSemanaNome[index].remove();

    linhaFiscaisSemanaIdguarnicao[index].insertAdjacentHTML("afterend",`
            <input class="idFiscal" name="idfiscal" type="hidden" value="`+FiscalId+`">
            <label class="nome" name="nome">`+fiscalName+`</label>
    `);

    linhaComandantesSemanaId[index].remove();
    linhaComandantesSemanaNome[index].remove();

    console.log(linhaFiscaisSemanaIdguarnicao);
    console.log(linhaComandantesSemanaIdGuarda);
    console.log(linhaCabosSemanaIdGuarda);

    
    linhaComandantesSemanaIdGuarda[index].insertAdjacentHTML("afterend",`
    <input class="idComandante" name="idAtirador" type="hidden" value="`+ComandanteId+`">
    <label class="nome" name="nome">`+ComandanteName+`</label>
    `);
    
    linhaCabosSemanaId[index].remove();
    linhaCabosSemanaNome[index].remove();

    linhaCabosSemanaIdGuarda[index].insertAdjacentHTML("afterend",`
    <input class="IdCabos" name="idAtirador" type="hidden" value="`+CaboID+`">
    <label class="nome" name="nome">`+CaboName+`</label>`);

    /*
    linhaFiscaisSemana[index].innerHTML =`
    <input name="idfiscal" type="hidden" value="`+FiscalId+`"> 
    <label name="nome">`+fiscalName+`</label> 
    `;

    linhaComandantesSemana[index].innerHTML = `
    <input name="id" type="hidden" value="`+ComandanteId+`"> 
    <input name="Funcao" type="hidden" value="Comandante">
    <label name="nome">`+ComandanteName+`</label> 
    `;

    linhaCabosSemana[index].innerHTML = `
    <input name="id" type="hidden" value="`+CaboID+`"> 
    <input name="Funcao" type="hidden" value="Cabo">
    <label name="nome">`+CaboName+`</label> 
    `
*/
    let classe;
    let linhaSentinelas;
    var contador = 1;

    atiradoresLista.forEach(function (item, indice, array)
     {
        let linhaIdAtirador;
        let linhaNomeAtirador;
        let linhaIdGuarda;

        // Alterar aqui para ficar semelhante aos de cima
        classe ='#linha-sentinela0'+contador+' td .idAtirador';
        contador+=1;

        linhaSentinelas = document.querySelectorAll(classe);
        linhaSentinelas[index].innerHTML = `
        <input name="id" type="hidden" value="`+item.id+`"> 
        <input name="Funcao" type="hidden" value="Sentinela">
        <label name="nome">`+item.nome+`</label> 
        `;
    });

    
    let listaAtiradores = document.querySelector('.myList');
    listaAtiradores.innerHTML = ""

     atiradores = [];
     sentinelas = [];
     atiradoresLista = [];
     id_dia = "";
     contador =1;

     disposeModal();

});
