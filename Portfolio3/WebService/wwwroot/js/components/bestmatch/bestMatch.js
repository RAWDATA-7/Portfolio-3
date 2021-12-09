define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let bestmatch = ko.observableArray([]);

        let prev = ko.observable();

        let next = ko.observable();

        let getData = () => {
            ds.getBestMatch(data => {
                prev(data.prev || undefined);
                next(data.next || undefined);
                bestmatch(data.items);
            });
        }

        let showPrev = bestmatch => {
            console.log(prev());
            getData(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = bestmatch => {
            console.log(next());
            getData(next());
        }
        let goToTitle = (data) => {
            postman.publish("changeView", { view: "get-titleinfo", url: data.url });
        }

        let enableNext = ko.computed(() => next() !== undefined);

        getData();

        return {
            goToTitle,
            bestmatch,
            showPrev,
            enablePrev,
            enableNext,
            showNext
        };
    };
});