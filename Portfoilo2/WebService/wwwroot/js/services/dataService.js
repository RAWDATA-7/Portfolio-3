define([], () => {

    let getBestRatedTitles = (callback) => {
        fetch("api/BestRatedTitles")
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getBestRatedTitles,
    }
});