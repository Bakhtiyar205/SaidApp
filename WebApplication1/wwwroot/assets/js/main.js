

$(document).ready(function () {
    console.log();

    window.onload = function () {
        this.window.scrollTo(0, 0)
        let firstPartText = $(".first-part-text");
        $(firstPartText).css({ "opacity": "1", "transform": "translateX(0)" });

        let secondaryPart = $(".secondary-part");
        $(secondaryPart).css("opacity", "1");

        let headerNav = $(".header-transition");
        $(headerNav).css({ "opacity": "1" });
        if (document.body.scrollHeight < 1300) {
            let footerTransition = $(".footer-transition")
            $(footerTransition).css({ "opacity": "1", "transform": "translateY(0)" })
        }
    }

    //window.addEventListener("load", function () {
    //    this.window.scrollTo(0, 0)
    //    let firstPartText = $(".first-part-text");
    //    $(firstPartText).css({ "opacity": "1", "transform": "translateX(0)" });

    //    let secondaryPart = $(".secondary-part");
    //    $(secondaryPart).css("opacity", "1");

    //    let headerNav = $(".header-transition");
    //    $(headerNav).css({ "opacity": "1" });
    //});

    window.addEventListener("scroll", function () {
        if (this.window.pageYOffset > 300) {
            let sales = $(".sales")
            $(sales).css({ "opacity": "1", "transform": "translateX(0)" })
            let thirdCards = $(".third-cards")
            $(thirdCards).css({ "opacity": "1", "transform": "translateX(0)" })
        }

        if (this.window.pageYOffset > 700) {
            let forthPart = $(".forth-part")
            $(forthPart).css({ "opacity": "1", "transform": "translateX(0)" })
        }

        if (this.window.pageYOffset > 1100) {
            let transitionSixth = $(".transition")
            $(transitionSixth).css({ "opacity": "1", "transform": "translateX(0)" })
        }


        let footerTransition = $(".footer-transition");
        if (document.body.scrollHeight > 2200) {
            if (this.window.pageYOffset > 1700) {
                $(footerTransition).css({ "opacity": "1", "transform": "translateY(0)" })
            }
        } else if (document.body.scrollHeight > 1500) {
            if (this.window.pageYOffset > 800) {
                $(footerTransition).css({ "opacity": "1", "transform": "translateY(0)" })
            }
        }

    })

    // Tabs
    let saleComponent = $(".sale-component");
    let thirdCards = $(".third-cards");
    $(saleComponent).click(function (e) {
        e.preventDefault();
        for (let i = 0; i < saleComponent.length; i++) {
            $(saleComponent[i]).removeClass("sale-component-active");
            $(thirdCards[i]).addClass("d-none");
            $(thirdCards[i]).removeClass("d-block");
        }

        $(this).addClass("sale-component-active");
        let index = saleComponent.index($(this));
        $(thirdCards[index]).removeClass("d-none");
    })

    // Nav Catalog Hover
    let catalogNav = $('#catalog-nav');
    let catalogCategories = $('#catalog-categories');
    let primaryUlNav = $('#primary-ul-nav');
    let catalogCategoriesClassList = document.getElementById('catalog-categories').classList;

    // Catalog Hover
    $(catalogNav).hover(function (e) {
        catalogCategories.addClass("catalog-hover");
    })

    // Primary Ul Nav Mouse Leave
    $(primaryUlNav).mouseleave(function (e) {
        if (catalogCategoriesClassList.contains("catalog-hover")) {
            catalogCategories.removeClass("catalog-hover");
        }
    })





});