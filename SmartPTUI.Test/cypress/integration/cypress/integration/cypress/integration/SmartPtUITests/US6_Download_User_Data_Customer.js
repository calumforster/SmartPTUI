
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('body').click();
        cy.get('.navbar').click();
        cy.get('#login').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Login');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('eddietest@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('.btn').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('#manage').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Manage');
        cy.get('#personal-data').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Manage/PersonalData');
        cy.get('.btn-primary').click();
        cy.get('#logout').click();
        cy.url().should('contains', 'https://localhost:5001/');

        expect(true).to.equal(true);
    })
})