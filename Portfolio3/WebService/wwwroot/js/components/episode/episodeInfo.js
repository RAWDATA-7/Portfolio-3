define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let episode = ko.observable();

        postman.subscribe("showView", url => {
            ds.getEpisode(url, e => {
                episode(e);
            });
        })

        let goToParent= (data) => {
            postman.publish("changeView", { view: "get-titleinfo", url: data.id });
        }

        return {
            episode,
            goToParent
        };
    };
});