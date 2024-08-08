import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventModerationComponent } from './event-moderation.component';

describe('EventModerationComponent', () => {
  let component: EventModerationComponent;
  let fixture: ComponentFixture<EventModerationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EventModerationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventModerationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
