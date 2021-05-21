
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/Identity/Account/Login');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('pttest10@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('.btn').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('.nav-item:nth-child(3) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/PT');
        cy.get('#CustomerEmail').click();
        cy.get('#CustomerEmail').type('eddietest@test.com');
        cy.get('.btn-primary').click();
        cy.get('form:nth-child(2)').submit();
        cy.url().should('contains', 'https://localhost:5001/PT');

        expect(true).to.equal(true);
    })
})