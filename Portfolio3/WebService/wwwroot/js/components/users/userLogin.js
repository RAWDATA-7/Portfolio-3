define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let name = ko.observable();
        let password = ko.observable();


        let login = () => {
            postman.publish("userLogin", {
                name: name(),
                password: password(),
            });
            postman.publish("changeView", "get-userinfo");
        }

        postman.subscribe("userLogin", name => {
            ds.getUserInfo(name, userLogin => {
            });
        }, "get-userinfo");

        let createUser = () => {
            postman.publish("changeView", "post-newuser")
        }

        return {
            name,
            password,
            login,
            createUser,
        };
    };
});