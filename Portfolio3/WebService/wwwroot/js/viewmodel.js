define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("get-bestratedtitles");
    let searchString = ko.observable();


    let menuItems = [
        { title: "Titles", component: "get-bestratedtitles" },
        { title: "Actors", component: "get-bestratedactors" },
        { title: "Create User", component: "post-newuser" },
        { title: "Login", component: "post-userlogin" },
        { title: "User Page", component: "get-userinfo" },
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