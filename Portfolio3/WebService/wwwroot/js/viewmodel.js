define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("get-bestratedtitles");

    let menuItems = [
        { title: "Create User", component: "post-newuser" },
        { title: "Titles", component: "get-bestratedtitles" },
        { title: "Actors", component: "get-bestratedactors" }
    ];

    let changeContent = menuItem => {
        console.log(menuItem);
        currentView(menuItem.component)
    };

    let isActive = menuItem => {
        return menuItem.component === currentView() ? "active" : "";
    }


    postman.subscribe("changeView", function (data) {
        currentView(data);
    });

    return {
        currentView,
        menuItems,
        changeContent,
        isActive
    }
});