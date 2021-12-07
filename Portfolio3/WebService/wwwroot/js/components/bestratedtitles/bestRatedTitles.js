define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let bestratedtitles = ko.observableArray([]);

        let prev = ko.observable();

        let next = ko.observable();

        let getData = url => {
            ds.getBestRatedTitles(url, data => {
                prev(data.prev || undefined);
                next(data.next);
                bestratedtitles(data.items);
            });
        }

        let showPrev = bestratedtitles => {
            console.log(prev());
            getData(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = bestratedtitles => {
            console.log(next());
            getData(next());
        }

        //let enableNext = ko.computed(() => next() !== null);


        getData();

        return {
            bestratedtitles,
            showPrev,
            enablePrev,
            //enableNext,
            showNext
        };
    };
});