let expect = require('chai').expect;
let mathEnforcer = require('./problem-04');

describe('mathEnforcer', function() {
    it('should return undefined if parameter type differs from number.', function() {
        expect(mathEnforcer.addFive('five')).to.equal(undefined, 'Function did not return the correct result');
    });

    it('should return 1.7976931348623157e+308 parameter value is Number.MAX_VALUE.', function() {
        expect(mathEnforcer.addFive(Number.MAX_VALUE)).to.equal(1.7976931348623157e+308, 'Function did not return the correct result');
    });

    it('should return "10" if parameter value is the number "5".', function() {
        expect(mathEnforcer.addFive(5)).to.equal(10, 'Function did not return the correct result');
    });

    it('should return "0" if parameter value is the number "-5".', function() {
        expect(mathEnforcer.addFive(-5)).to.equal(0, 'Function did not return the correct result');
    });

    it('should return undefined if parameter type differs from number.', function() {
        expect(mathEnforcer.subtractTen('five')).to.equal(undefined, 'Function did not return the correct result');
    });

    it('should return "10" if parameter value is the number "5".', function() {
        expect(mathEnforcer.subtractTen(20)).to.equal(10, 'Function did not return the correct result');
    });

    it('should return "-20" if parameter value is the number "-10".', function() {
        expect(mathEnforcer.subtractTen(-10)).to.equal(-20, 'Function did not return the correct result');
    });

    it('should return 1.7976931348623157e+308 if parameter value is the number Number.MAX_VALUE.', function() {
        expect(mathEnforcer.subtractTen(Number.MAX_VALUE)).to.equal(1.7976931348623157e+308, 'Function did not return the correct result');
    });

    it('should return undefined if first parameter type differs from number.', function() {
        expect(mathEnforcer.sum('five', 5)).to.equal(undefined, 'Function did not return the correct result');
    });

    it('should return undefined if second parameter type differs from number.', function() {
        expect(mathEnforcer.sum(5, 'five')).to.equal(undefined, 'Function did not return the correct result');
    });

    it('should return "10" if both parameters are of type number.', function() {
        expect(mathEnforcer.sum(5, 5)).to.equal(10, 'Function did not return the correct result');
    });

    it('should return "-10" if both parameters are of type number.', function() {
        expect(mathEnforcer.sum(-5, -5)).to.equal(-10, 'Function did not return the correct result');
    });

    it('should return undefined if both parameters are not of type number', function() {
        expect(mathEnforcer.sum('five', 'five')).to.equal(undefined, 'Function did not return the correct result');
    });

    //
    it('should return "1e-323" if both parameters are Number.MIN_VALUE', function() {
        expect(mathEnforcer.sum(Number.MIN_VALUE, Number.MIN_VALUE))
        .to.equal(1e-323, 'Function did not return the correct result');
    });

    it('should return "Infinity" if both parameters are Number.MAX_VALUE', function() {
        expect(mathEnforcer.sum(Number.MAX_VALUE, Number.MAX_VALUE))
        .to.equal(Infinity, 'Function did not return the correct result');
    });
    
    it('should return "1.7976931348623157e+308" if one of the parameters is Number.MAX_VALUE and the other is Number.MIN_VALUE', function() {
        expect(mathEnforcer.sum(Number.MAX_VALUE, Number.MIN_VALUE))
        .to.equal(1.7976931348623157e+308, 'Function did not return the correct result');
    });
});