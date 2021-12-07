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

    return {
        getBestRatedTitles,
        getBestRatedActors,
        newUserDS
    }
});