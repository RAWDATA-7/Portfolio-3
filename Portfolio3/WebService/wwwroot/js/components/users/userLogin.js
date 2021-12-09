define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let name = ko.observable();
        let password = ko.observable();

      
        let login = () => {
            ds.userLogin({
                name: name(),
                password: password(),
            }, data => {
                if (data) {
                    localStorage.setItem("user", data.name);
                    localStorage.setItem("token", data.token);
                }
                else {
                    localStorage.setItem("user", undefined);
                    localStorage.setItem("token", undefined);
                }
                postman.publish("changeViewUnhacked", "get-userinfo");
            })
        }

        postman.subscribe("userLogin", name => {
            ds.getUserInfo(name, userLogin => {
            });
        }, "get-userinfo");

        let createUser = () => {
            postman.publish("changeViewUnhacked", "post-newuser")
        }

        return {
            name,
            password,
            login,
            createUser,
        };
    };
});