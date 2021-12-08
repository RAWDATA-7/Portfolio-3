define([], () => {

    let getJson = (url, callback) => {
        fetch(url).then(response => response.json()).then(callback);
    };

    let getBestRatedTitles = (url, callback) => {
        if (url === undefined) {
            url = "api/BestRatedTitles";
        }
        getJson(url, callback);
    };

    let getEpisode = (url, callback) => {
        getJson(url, callback);
    };

    let getEpisodes = (url, callback) => {
        getJson(url, callback);
    };

    let getTitle = (url, callback) => {
        getJson(url, callback);
    }

    let getActor = (url, callback) => {
        getJson(url, callback);
    }

    let getUserInfo = (userId, callback) => {
        getJson("api/User/12", callback);
    }

    let getBestRatedActors = (url, callback) => {
        if (url === undefined) {
            url = "api/BestRatedActor";
        }
        getJson(url, callback);
    };


    let newUserDS = (user, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(user),
            headers: {
                "Content-Type": "application/json"
            }
        }
        fetch("api/AuthUser/CreateUser", param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    let userLogin = (userLogin, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(user),
            headers: {
                "Content-Type": "application/json"
            }
        }
        fetch("api/AuthUser/UserLogin", param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getBestRatedTitles,
        getBestRatedActors,
        getTitle,
        getActor,
        getEpisodes,
        getEpisode,
        userLogin,
        getUserInfo,
        newUserDS
    }
});