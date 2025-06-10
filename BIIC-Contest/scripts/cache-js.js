function getLocalStorage(key) {
    const storedData = localStorage.getItem(key);
    return storedData ? JSON.parse(storedData) : defaultData;
}

function saveLocalStorage(key, storedData) {
    localStorage.setItem(key, JSON.stringify(storedData));
}
