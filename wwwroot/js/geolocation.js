export async function getCurrentPosition() {
    var latitude = 0.0;
    var longitude = 0.0;
    var promise = new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(resolve);
    });
    await promise.then((position) => {
        latitude = position.coords.latitude;
        longitude = position.coords.longitude;
    });

    return { latitude: latitude, longitude: longitude };
}

export function getMuni(municd) {
    if (GSI.MUNI_ARRAY[municd]) {
        return GSI.MUNI_ARRAY[municd];
    }
    else {
        return "";
    }
}

