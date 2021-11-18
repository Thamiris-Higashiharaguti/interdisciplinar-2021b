class NavBar{
    constructor(menu,navList, navLinks){
        this.menu = document.querySelector(menu);
        this.navList = document.querySelector(navList);
        this.navLinks = document.querySelectorAll(navLinks);
        this.activeClass = "active";

        this.handleClick = this.handleClick.bind(this); //para a referencia continuar sendo do objeto
        }

    animateLinks(){
        this.navLinks.forEach((link,index) => {
            link.style.animation ? (link.style.animation = "")
             : (link.style.animation = `navLinkFade 0.5s ease forwards
             ${index/7 + 0.3}s`);
        });
    }


    handleClick()
    {
        this.navList.classList.toggle(this.activeClass);
        this.menu.classList.toggle(this.activeClass);
        this.animateLinks();
    }

    addClickEvent()
    {
        this.menu.addEventListener("click", () => this.handleClick());
    }

    init()
    {
        if(this.menu)
        {
            this.addClickEvent();
        }
        return this;
    }
}
const ObNavBar = new NavBar(
    ".mobile-menu",
    ".nav-list",
    ".nav-list li"
);

ObNavBar.init();