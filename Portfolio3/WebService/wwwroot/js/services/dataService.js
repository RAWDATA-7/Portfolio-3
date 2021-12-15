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

    let bookmarkTitle = (bookmark, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(bookmark),
            headers: {
                "Content-Type": "application/json"
            }
        }
        fetch("api/Title/Bookmark", param)
            .then(response => response.json())
            .then(json => callback(json));
    };


    let rateTitle = (rating, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(rating),
            headers: {
                "Content-Type": "application/json"
            }
        }
        fetch("api/Title/UserRating", param)
            .then(response => response.json())
            .then(json => callback(json));
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

    let getUserInfo = (callback) => {
        let param = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        }
        fetch("api/User/" + localStorage.getItem("user"), param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    let getBestRatedActors = (url, callback) => {
        if (url === undefined) {
            url = "api/BestRatedActor";
        }
        getJson(url, callback);
    };


    let getBestMatch = (callback) => {
        url = "api/BestMatch?uId=" + localStorage.getItem("id") + "&searchString=" + localStorage.getItem("searchString") + "&field=f"
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
            body: JSON.stringify(userLogin),
            headers: {
                "Content-Type": "application/json"
            }
        }
        fetch("api/AuthUser/UserLogin", param)
            .then(response => {
                if (response.status !== 200) {
                    return undefined;
                }
                return response.json();
            })
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
        getBestMatch,
        newUserDS,
        bookmarkTitle,
        rateTitle
    }
});