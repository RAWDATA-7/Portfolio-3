define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {

        let name = ko.observable();
        let firstname = ko.observable();
        let lastname = ko.observable();
        let email = ko.observable();
        let sex = ko.observable();
        let plaintxtpwd = ko.observable();

        let add = () => {
            postman.publish("newUser", {
                name: name(),
                firstname: firstname(),
                lastname: lastname(),
                email: email(),
                sex: sex(),
                plaintxtpwd: plaintxtpwd()
            });
        }

        postman.subscribe("newUser", user => {
            ds.newUserDS(user, newUser => {
                //categories.push(newUser);
            });
        }, "get-bestratedtitles");
    

        return {
            name,
            firstname,
            lastname,
            email,
            sex,
            plaintxtpwd,
            add
        };
    };
});