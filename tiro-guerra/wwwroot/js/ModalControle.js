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
    var value = select.options[select.selectedIndex].value;

    if(atiradores.length < 6)
    {

        atiradores.push(value)
    
        atiradoresLista.push({
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
    var Fiscal = select.options[select.selectedIndex].value;

    var select = document.getElementById('comandante');
    var Comandante = select.options[select.selectedIndex].value;

    var select = document.getElementById('cabo');
    var Cabo = select.options[select.selectedIndex].value;


    atiradoresLista.push({
        nome: Fiscal,
        funcao: 'Fiscal'
    });

    atiradoresLista.push({
        nome: Comandante,
        funcao: 'Comandante'
    });

    atiradoresLista.push({
        nome: Cabo,
        funcao: 'Cabo'
    });

    let comandante;
    let fiscal;
    let cabo;
    let sentinelas = [];

    atiradoresLista.forEach(function (item, indice, array)
     {
         if(item.funcao == "Fiscal")
         {
             fiscal = item.nome;
         }

         if(item.funcao == "Comandante")
         {
             comandante = item.nome;
         }

         if(item.funcao == "Cabo")
         {
             cabo = item.nome;
         }

         if(item.funcao =="Sentinela"){
            sentinelas.push(item.nome);
         }
         
    });

    console.log(atiradoresLista);
      
    var index = id_dia -1;

    let linhaFiscaisSemana = document.querySelectorAll('#linha-fiscal td');
    let linhaComandantesSemana = document.querySelectorAll('#linha-comandante td');
    let linhaCabosSemana = document.querySelectorAll('#linha-cabo td');


    linhaFiscaisSemana[index].innerHTML = fiscal;
    linhaComandantesSemana[index].innerHTML = comandante;
    linhaCabosSemana[index].innerHTML = cabo;

    let classe;
    let linhaSentinelas;
    var contador = 1;

    sentinelas.forEach(function(item,indice,array)
    {
        classe ='#linha-sentinela0'+contador+' td';
        contador+=1;

        linhaSentinelas = document.querySelectorAll(classe);
        linhaSentinelas[index].innerHTML = item;
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
