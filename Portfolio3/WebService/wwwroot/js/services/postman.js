define([], () => {
    let subscribers = [];

    let lastEvent = {};

    let subscribe = (event, callback, target) => {
        let subscriber = { event, callback, target };

        if (!subscribers.find(x => x.target === target && x.event === event))
            subscribers.push(subscriber);
        //tillader at hvis der er en subscriber et sted at de får lov til at udføre eventet inden det overskrives.
        if (lastEvent[event]) {
            callback(lastEvent[event]);
        }
    };
    let publish = (event, data) => {
        subscribers.forEach(x => {
            if (x.event === event) x.callback(data);
        });
        //asynkron hackings 
        // gør at der oprettes en slags kø, hvori alle events som er published kommer til at ligge. 
        lastEvent[event] = data;
    };

    return {
        subscribe,
        publish
    }

});