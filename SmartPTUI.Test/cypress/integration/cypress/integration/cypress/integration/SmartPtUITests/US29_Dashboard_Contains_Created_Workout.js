var hashNo = Math.random() * (20000 - 1) + 1;



describe('My First Test', () => {
    it('Does not do much!', () => {

        cy.visit('https://localhost:5001/');
        cy.get('.flex-grow-1').click();
        cy.get('#register').click();
        cy.url().should('contains', 'https://localhost:5001/Identity/Account/Register');
        cy.get('#Input_FirstName').click();
        cy.get('#Input_FirstName').type('Cypress');
        cy.get('#Input_LastName').type('Test');
        cy.get('#Input_Gender').select('Male');
        cy.get('#Input_Height').click();
        cy.get('#Input_Height').type('180');
        cy.get('#Input_CurrentHealthRating').select('Good');
        cy.get('#Input_DOB').click();
        cy.get('#Input_DOB').type('1990-09-19');
        cy.get('#Input_Email').click();
        cy.get('#Input_Email').type('cypresstest' + hashNo + '@test.com');
        cy.get('#Input_Password').click();
        cy.get('#Input_Password').type('Welcome123!');
        cy.get('#Input_ConfirmPassword').click();
        cy.get('#Input_ConfirmPassword').type('Welcome123!');
        cy.get('.btn').click();

        cy.url().should('contains', 'https://localhost:5001/');
        cy.get('.nav-item:nth-child(4) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/WorkoutQuestionnaire');
        cy.get('#WorkoutQuestion_WorkoutName').click();
        cy.get('#WorkoutQuestion_WorkoutName').type('Cypress');
        cy.get('#WorkoutQuestion_StartWeight').click();
        cy.get('#WorkoutQuestion_StartWeight').type('100');
        cy.get('.form-group:nth-child(11)').click();
        cy.get('#WorkoutQuestion_EndWeight').click();
        cy.get('#WorkoutQuestion_EndWeight').type('90');
        cy.get('#WorkoutQuestion_NumberOfWeeks').click();
        cy.get('#WorkoutQuestion_NumberOfWeeks').type('6');
        cy.get('#WorkoutQuestion_DaysPerWeek').click();
        cy.get('#WorkoutQuestion_DaysPerWeek').type('4');
        cy.get('#WorkoutQuestion_TimePerWorkout').click();
        cy.get('#WorkoutQuestion_TimePerWorkout').type('4');
        cy.get('.btn-primary').click();
        cy.url().should('contains', 'https://localhost:5001/Workout');
        cy.get('.nav-item:nth-child(3) > .nav-link').click();
        cy.url().should('contains', 'https://localhost:5001/Dashboard');
        cy.get('.btn-secondary').click();
        cy.url().should('contains', 'https://localhost:5001/Workout');
        cy.get('#logout').click();
        cy.url().should('contains', 'https://localhost:5001/');


        expect(true).to.equal(true);
    })
})