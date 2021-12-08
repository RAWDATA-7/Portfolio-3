define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let title = ko.observable();

        postman.subscribe("showView", url => {
            ds.getTitle(url, t => {
                title(t);
            });
        })

        let goToEpisodes = (data) => {
            postman.publish("changeView", { view: "get-episodes", url: data.episodesUrl });
        }

        let goToParent = (data) => {
            postman.publish("changeView", { view: "get-bestratedtitles" });
            postman.publish("changeView", { view: "get-titleinfo", url: data.parentUrl });
        }

        return {
            title,
            goToEpisodes,
            goToParent
        };
    };
});