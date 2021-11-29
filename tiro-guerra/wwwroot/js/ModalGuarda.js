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