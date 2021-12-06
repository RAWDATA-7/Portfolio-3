
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
    ko.components.register("get-userinfo", {
        viewModel: { require: "components/users/userInfo" },
        template: { require: "text!components/users/userInfo.html" }
    });
    ko.components.register("get-actorinfo", {
        viewModel: { require: "components/actors/actorInfo" },
        template: { require: "text!components/actors/actorInfo.html" }
    });
    ko.components.register("get-titleinfo", {
        viewModel: { require: "components/titles/titleInfo" },
        template: { require: "text!components/titles/titleInfo.html" }
    });
    ko.components.register("get-bestratedactors", {
        viewModel: { require: "components/bestratedactors/bestRatedActors" },
        template: { require: "text!components/bestratedactors/bestRatedActors.html" }
    });
});
require(["knockout", "viewmodel", "bootstrap"], function (ko, vm) {
    ko.applyBindings(vm);
});