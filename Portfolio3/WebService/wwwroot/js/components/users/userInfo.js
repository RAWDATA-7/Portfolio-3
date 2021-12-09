define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let user = ko.observable();

        ds.getUserInfo(data => {
            user(data);
            localStorage.setItem("id", data.id);
        });

        return {
            user
        };
    };
});