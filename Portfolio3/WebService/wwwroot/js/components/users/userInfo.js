define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let user = ko.observable();

        user(ds.getUserInfo("6"));

        return {
            user
        };
    };
});