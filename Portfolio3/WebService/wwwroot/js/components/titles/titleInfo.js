define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let title = ko.observable();
        let ratings = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];


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
        let goToActor = (data) => {
            postman.publish("changeView", { view: "get-actorinfo", url: data });
        }

        let bookmarking = (data) => {
            postman.publish("BookmarkTitle", {
                uId: localStorage.getItem("id"),
                tId: data.id
            });
        }

        postman.subscribe("BookmarkTitle", bookmark => {
            ds.bookmarkTitle(bookmark, BookmarkTitle => {

            });
        }, "get-titleinfo");

        let rate = (data) => {
            postman.publish("RateTitle", {
                uId: localStorage.getItem("id"),
                tId: data.id,
                rating: document.getElementById("selectedRating").value
            });
        }

        postman.subscribe("RateTitle", rating => {
            ds.rateTitle(rating, RateTitle => {

            });
        }, "get-titleinfo");



        return {
            title,
            ratings,
            rate,
            goToEpisodes,
            goToParent,
            goToActor,
            bookmarking
        };
    };
});