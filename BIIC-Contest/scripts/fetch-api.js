async function fectchApi(apiURL, type, postData) {
    try {
        if (type === 'POST') {
            const data = await postApi(apiURL, postData);
            return data;
        }

        if (type == 'GET') {
            const data = await getApi(apiURL);
            return data;
        }
    } catch (ex) {
        throw new Error(`Fectch data api err: ${ex}`);
    }
}

async function getApi(apiURL) {
    try {
        const response = await fetch(apiURL);

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();

        return data;
    } catch (ex) {
        throw new Error(`Fectch get api err: ${ex}`);
    }
}

async function postApi(apiURL, postData) {
    try {
        const response = await fetch(apiURL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postData)
        });

        if (!response.ok) {
            console.log(response)
            return;
        }

        const data = await response.json();

        return data;
    } catch (ex) {
        throw new Error(`Fectch post api error: ${ex}`);
    }
}

async function postFileApi(apiURL, formData) {
    try {
        const response = await fetch(apiURL, {
            method: 'POST',
            body: formData
        });

        if (!response.ok) {
            console.log(response);
            return;
        }

        const data = await response.json();
        return data;
    } catch (ex) {
        throw new Error(`Fetch post file api error: ${ex}`);
    }
}