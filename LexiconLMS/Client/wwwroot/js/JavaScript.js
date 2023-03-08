function reloadParent(message) {

    console.log('Message from javascript', message);

    parent.location.reload();
}