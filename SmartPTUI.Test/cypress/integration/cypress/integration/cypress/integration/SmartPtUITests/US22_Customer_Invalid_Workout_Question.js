
describe('My First Test', () => {
    it('Does not do much!', () => {
        cy.visit('https://localhost:5001/');
        cy.get('.text-center:nth-child(6) > .display-5').click();
        cy.get('#login').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Login');
        cy.get('.container:nth-child(2)').click();
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('eddietest@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('.btn').click();
        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('.nav-item:nth-child(4) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/WorkoutQuestionnaire');
        cy.get('#WorkoutQuestion_WorkoutName').click();
        cy.get('#WorkoutQuestion_WorkoutName').type('Cypress');
        cy.get('#WorkoutQuestion_StartWeight').click();
        cy.get('#WorkoutQuestion_StartWeight').type('abc');
        cy.get('#WorkoutQuestion_EndWeight').click();
        cy.get('#WorkoutQuestion_EndWeight').type('abc');
        cy.get('#WorkoutQuestion_NumberOfWeeks').click();
        cy.get('#WorkoutQuestion_NumberOfWeeks').type('a');
        cy.get('#WorkoutQuestion_DaysPerWeek').click();
        cy.get('#WorkoutQuestion_DaysPerWeek').type('a');
        cy.get('#WorkoutQuestion_TimePerWorkout').click();
        cy.get('#WorkoutQuestion_TimePerWorkout').type('a');
        cy.get('.btn-primary').click();
        cy.get('.form').submit();
        cy.url().should('contains', 'https://localhost:5001/WorkoutQuestionnaire/SubmitForm');

        expect(true).to.equal(true);
    })
})