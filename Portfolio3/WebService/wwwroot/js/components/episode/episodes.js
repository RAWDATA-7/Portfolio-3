define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let episodes = ko.observableArray();


        let prev = ko.observable();

        let next = ko.observable();

        let goToEpisode = (data) => {
            postman.publish("changeView", { view: "get-titleinfo", url: "https://localhost:5001/api/Title/" + data.id });
        }

        let getData = url => {
            postman.subscribe("showView", url => {
                ds.getEpisodes(url, data => {
                    prev(data.prev || undefined);
                    next(data.next || undefined);
                    episodes(data.items);
                });
            })
        }

        let getDataForPaging = url => {ds.getEpisodes(url, data => {
            prev(data.prev || undefined);
            next(data.next || undefined);
            episodes(data.items);
        });
        }

        let showPrev = episodes => {
            console.log(prev());
            getDataForPaging(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = episodes => {
            console.log(next());
            getDataForPaging(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        getData();

        return {
            episodes,
            goToEpisode,
            showNext,
            showPrev,
            enableNext,
            enablePrev
        };
    };
});