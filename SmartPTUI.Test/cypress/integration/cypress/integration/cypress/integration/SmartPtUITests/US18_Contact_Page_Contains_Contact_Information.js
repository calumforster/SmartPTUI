
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('.flex-grow-1 > .nav-item:nth-child(2) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/Home/Contact');


        expect(true).to.equal(true);
    })
})