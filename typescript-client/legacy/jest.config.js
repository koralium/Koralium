module.exports = {
  preset: 'ts-jest',
  testEnvironment: 'node',
  testResultsProcessor: 'jest-sonar-reporter',
  coveragePathIgnorePatterns: [
    "/node_modules/",
    "/test/",
    "/generated/"
  ],
  testPathIgnorePatterns: ["lib"]
};