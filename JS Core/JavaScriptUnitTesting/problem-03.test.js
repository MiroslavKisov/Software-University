let expect = require('chai').expect;
let lookupChar = require('./problem-03');

describe('lookupChar', function() {
    it('should return undefined with argument type different from string as first parameter', function() {
        expect(lookupChar(5, 8)).to.equal(undefined, 'Function did not return the correct result');
    });

    it('should return undefined with floating point number as second parameter', function() {
        expect(lookupChar('pesho', 5.8)).to.equal(undefined, 'Function did not return the correct result');
    });

    it('should return undefined with both parameters incorrect', function() {
        expect(lookupChar(5, 5.8)).to.equal(undefined, 'Function did not return the correct result');
    });

    it('should return Incorrect index with negative index', function() {
        expect(lookupChar('abc', -1)).to.equal('Incorrect index', 'Function dod not return the correct result');
    });

    it('should return Incorrect index with index larger than the string length', function() {
        expect(lookupChar('abc', 3)).to.equal('Incorrect index', 'Function did not return the correct result');
    });

    it('should return "y" with correct index value', function() {
        expect(lookupChar('qwerty', 5)).to.equal('y', 'Function did not return the correct result');
    });
});