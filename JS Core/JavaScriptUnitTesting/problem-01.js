function solve(obj) {

    let methodPattern = /^GET$|^POST$|^DELETE$|^CONNECT$/gm;
    let uriPattern = /^([A-Za-z0-9\.]*[A-Za-z0-9]*|\*{1})$/gm;
    let versionPattern = /HTTP\/0.9|HTTP\/1.0|HTTP\/1.1|HTTP\/2.0/gm;
    let messagePattern = /^((?!<)(?!>)(?!&)(?!')(?!")(?!\\).)*$/gm;

    if(!methodPattern.test(obj.method) || obj.method === undefined) {
        throw Error('Invalid request header: Invalid Method');
    }

    if(!uriPattern.test(obj.uri) || obj.uri === '' || obj.uri === undefined) {
        throw Error('Invalid request header: Invalid URI');
    }

    if(!versionPattern.test(obj.version) || obj.version === undefined) {
        throw Error('Invalid request header: Invalid Version');
    }

    if((!messagePattern.test(obj.message) && obj.message !== '') || obj.message === undefined) {
        throw Error('Invalid request header: Invalid Message');
    }

    return obj;
}
