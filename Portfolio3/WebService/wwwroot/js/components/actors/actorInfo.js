define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let actor = ko.observableArray([]);

        ds.getActor(id, actor);

        return {
            actor
        };
    };
});