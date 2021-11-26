
        function formatDate(date)
        {
            let dia =date.getDate();
            let mes = parseInt(date.getMonth())+1;
            let ano = date.getFullYear();
            
            let dia_brasil = (dia+"/"+mes+"/"+ano);
            return dia_brasil;
        }



        function loadDates()
        {
       
              //tela pre guarnição
                var data = document.querySelector("input[name=dataEscolhida]").value;
                var date =  new Date(data);

                if(data != "")
                {
                    var date =  new Date(data); //pode receber o parametro da data escolhida "mês/dia/ano"
                    date.setDate(date.getDate()+1); //soma 1 dia  a data passada

                    var firstDayofWeek = true
                    
                    while(firstDayofWeek)
                    {
                        if(date.getDay()==0)
                        {
                            firstDayofWeek = false;
                        }
                        else
                        {
                            date.setDate(date.getDate()-1);
                        }
                        
                    }

                var diaSemana = document.querySelectorAll("th[class=date]");
                var inputDiaSemana = document.querySelectorAll("input[class=diaSemana]");

                var dates_array = [];
                    
                    for(let i =0; i<7; i++)
                    {
                        let nova_data = new Date(date);
                        nova_data.setDate(nova_data.getDate()+i);
                        dates_array.push(nova_data);
                    }
                   
                    var array_dia_exibir = [];

                    dates_array.forEach(element => 
                    {
                        let dia = formatDate(element);
                        array_dia_exibir.push(dia);    
                    });


                    for(var i =0; i<array_dia_exibir.length; i++)
                    {
                        diaSemana[i].innerHTML=array_dia_exibir[i];
                        inputDiaSemana[i].value = array_dia_exibir[i];

                    }
                }


        }

        window.onload=loadDates();
