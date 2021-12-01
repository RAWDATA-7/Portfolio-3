define(["knockout", "postman"], function (ko, postman) {

    let currentView = ko.observable("get-bestratedtitles");

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });

    return {
        currentView
    }
});