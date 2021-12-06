define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let bestratedactors = ko.observableArray([]);

        ds.getBestRatedActors(bestratedactors);


        return {
            bestratedactors
        };
    };
});