﻿
require.config({
    baseUrl: 'js',
    paths: {
        text: "lib/requirejs/text",
        jquery: "lib/jquery/dist/jquery.min",
        knockout: "lib/knockout/build/output/knockout-latest.debug",
        bootstrap: "../css/lib/bootstrap/dist/js/bootstrap.bundle.min",
        dataService: "services/dataService",
        postman: "services/postman"
    }
});

// component registration
require(['knockout'], (ko) => {
    ko.components.register("get-bestratedtitles", {
        viewModel: { require: "components/bestratedtitles/bestRatedTitles" },
        template: { require: "text!components/bestratedtitles/bestRatedTitles.html" }
    });
    ko.components.register("post-newuser", {
        viewModel: { require: "components/users/createUser" },
        template: { require: "text!components/users/createUser.html" }
    });
});
require(["knockout", "viewmodel"], function (ko, vm) {
    ko.applyBindings(vm);
});