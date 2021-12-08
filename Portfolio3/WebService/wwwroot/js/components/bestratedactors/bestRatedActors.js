define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let bestratedactors = ko.observableArray([]);

        let prev = ko.observable();

        let next = ko.observable();

        let getData = url => {
            ds.getBestRatedActors(url, data => {
                prev(data.prev || undefined);
                next(data.next || undefined);
                bestratedactors(data.items);
            });
        }

        let showPrev = bestratedactors => {
            console.log(prev());
            getData(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = bestratedactors => {
            console.log(next());
            getData(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        let goToActor = (data) => {
            postman.publish("changeView", { view: "get-actorinfo", url: data.url });
        }


        getData();

        return {
            bestratedactors,
            showPrev,
            enablePrev,
            goToActor,
            enableNext,
            showNext
        };
    };
});