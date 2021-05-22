
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('body').click();
        cy.get('#login').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Login');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('admintest@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('.btn').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('.nav-item:nth-child(3) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/Home/FAQ');
        cy.get('.nav-item:nth-child(2) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/Home/Contact');
        cy.get('.flex-grow-1 > .nav-item:nth-child(1) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('#logout').click();
        cy.url().should('contains', 'https://localhost:5001/');


        expect(true).to.equal(true);
    })
})