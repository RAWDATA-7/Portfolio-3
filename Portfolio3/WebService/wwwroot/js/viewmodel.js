define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("post-newuser");

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });

    return {
        currentView
    }
});