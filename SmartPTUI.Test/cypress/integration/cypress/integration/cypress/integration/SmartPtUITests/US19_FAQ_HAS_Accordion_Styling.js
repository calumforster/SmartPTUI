
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('.text-center:nth-child(5)').click();
        cy.get('.flex-grow-1 > .nav-item:nth-child(3) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/Home/FAQ');
        cy.get('.info-panel:nth-child(1) summary').click();

        expect(true).to.equal(true);
    })
})