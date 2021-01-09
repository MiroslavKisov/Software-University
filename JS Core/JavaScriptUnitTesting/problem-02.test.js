const expect = require('chai').expect;
const isOddOrEven = require('./problem-02');

describe('isOddOrEven', function() {
    it('should return undefined', function() {
        expect(isOddOrEven(13)).to.equal(undefined, 'Function requires string parameter');
    });

    it('should return even', function() {
        expect(isOddOrEven('Pesh')).to.equal('even', 'Function do not work correctly with even string');
    });

    it('should return odd', function() {
        expect(isOddOrEven('Pesho')).to.equal('odd', 'Function do not work correctly with odd string');
    });
});