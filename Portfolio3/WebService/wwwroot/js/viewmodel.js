define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("get-bestratedtitles");
    let searchString = ko.observable();


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

    let saveSearchString = () => {
        localStorage.setItem("searchString", searchString());
        console.log(localStorage.getItem("searchString"));
        postman.publish("changeViewUnhacked", "get-bestmatch");
        }
               

    postman.subscribe("changeViewUnhacked", function (data) {
        currentView(data);
    });

    postman.subscribe("changeView", function (data) {
        currentView(data.view);
        if (data.url) {
            postman.publish("showView", data.url);
        }
    });

    return {
        currentView,
        searchString,
        menuItems,
        changeContent,
        saveSearchString,
        isActive
    }
});