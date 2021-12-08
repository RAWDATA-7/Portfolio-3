define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let actor = ko.observable();

        postman.subscribe("showView", url => {
            ds.getActor(url, a => {
                actor(a);
            });
        })

        return {
            actor
        };
    };
});