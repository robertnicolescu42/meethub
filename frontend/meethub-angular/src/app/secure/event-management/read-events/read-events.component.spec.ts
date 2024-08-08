import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadEventsComponent } from './read-events.component';

describe('ReadEventsComponent', () => {
  let component: ReadEventsComponent;
  let fixture: ComponentFixture<ReadEventsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReadEventsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReadEventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
