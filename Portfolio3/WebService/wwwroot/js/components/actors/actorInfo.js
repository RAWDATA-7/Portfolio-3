define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let actor = ko.observable();
 
        postman.subscribe("showView", url => {
            ds.getActor(url, a => {
                actor(a);
            });
        })

        let goToTitle = (data) => {
            postman.publish("changeView", { view: "get-titleinfo", url: data });
        }

        return {
            actor,
            goToTitle
        };
    };
});