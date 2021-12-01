define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let bestratedtitles = ko.observableArray([]);

        ds.getBestRatedTitles(bestratedtitles);


        return {
            bestratedtitles
        };
    };
});