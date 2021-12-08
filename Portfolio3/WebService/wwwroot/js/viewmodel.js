define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("get-bestratedtitles");

    let menuItems = [
        { title: "Create User", component: "post-newuser" },
        { title: "Titles", component: "get-bestratedtitles" },
        { title: "Actors", component: "get-bestratedactors" },
        { title: "Login", component: "post-userlogin" },
    ];

    let changeContent = menuItem => {
        console.log(menuItem);
        currentView(menuItem.component)
    };

    let isActive = menuItem => {
        return menuItem.component === currentView() ? "active" : "";
    }


    postman.subscribe("changeView", function (data) {
        currentView(data.view);
        if (data.url) {
            postman.publish("showView", data.url);
        }
    });

    return {
        currentView,
        menuItems,
        changeContent,
        isActive
    }
});